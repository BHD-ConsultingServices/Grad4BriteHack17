var challengeTypeEnum = { Undefined: 0, YesNo: 1, MultiChoice: 2 }

site.page = function () {
    var public = {};

    public.links = {};
    public.objectFactory = {};
    public.viewModel = {};
    public.dataAccess = {};

    return public;
}();

site.page.dataAccess = function () {
    var dal = {};

    dal.submitAnswers = function (answer, successCallback) {
        console.log(answer);

        site.ajax.submitAjaxGetJson(site.page.links.registerUrl, answer, successCallback);
    };

    return dal;
}();

site.page.objectFactory = function () {
    var public = {};

    public.getRegisterData = function (initiativeId, email, answers) {
        var request = {
            InitiativeId: initiativeId,
            Email: email,
            Answers: answers
        };

        return request;
    }

    var  convertQuestionToAnswer = function(original) {
        var answer = {
            ChallengeId: original.id,
            ChallengeType: original.type,
            YesNoAnswer: original.answerYesNo(),
            MultiAnswer: original.answerMulti()
        }
        
        return answer;
    }

    public.convertQuestionsToAnswers = function (originals) {
        return $.map(originals, convertQuestionToAnswer);
    }

    var getAnsweredQuestions = function () {
        var counter = 0;

        $.each(site.page.viewModel.challenges(), function (key, value) {
            if ((value.answerYesNo() != undefined && value.answerYesNo() !== "")
                || (value.answerMulti() != undefined && value.answerMulti() !== "")) {
                counter++;
            }
        });

        return counter;
    }

    var createChallenge = function (original) {
        var converted = {};

        converted.id = original.Id;
        converted.question = original.Question;
        converted.type = original.Type;

        var hasMulti = original.Type === challengeTypeEnum.MultiChoice;

        converted.optionA = hasMulti ? original.MultiChoiceChallenge.OptionA : "";
        converted.optionB = hasMulti ? original.MultiChoiceChallenge.OptionB : "";
        converted.optionC = hasMulti ? original.MultiChoiceChallenge.OptionC : "";
        converted.optionD = hasMulti ? original.MultiChoiceChallenge.OptionD : "";

        converted.answerYesNo = ko.observable(undefined);
        converted.answerYesNo.subscribe(function () {
            site.page.viewModel.numberOfCompleted(getAnsweredQuestions());
        }, this);

        converted.answerMulti = ko.observable(undefined);
        converted.answerMulti.subscribe(function () {
            site.page.viewModel.numberOfCompleted(getAnsweredQuestions());
        }, this);

        return converted;
    }

    public.createChallenges = function (originals) {
        return $.map(originals, createChallenge);
    }

    return public;
}();


site.createViewModel = function (serverData) {
    var public = {};

    console.log("Creating the client side view model.");
    console.log(serverData);

    var challengeData = site.page.objectFactory.createChallenges(serverData.Challenges);
    console.log(challengeData);

    public.initiativeId = serverData.InitiativeId;
    public.errorMessage = ko.observable("");
    public.successMessage = ko.observable("");
    public.email = ko.observable("");
    public.yesNoOptions = ko.observableArray([{ label: "Undefined", value: "" }, { label: "Yes", value: "Yes" }, { label: "No", value: "No" }]);
    public.challenges = ko.observableArray(challengeData);

    public.numberOfCompleted = ko.observable(0);
    public.isCompleted = ko.observable(false);

    public.numberOfQuestions = ko.computed(function () {
        return public.challenges().length;
    });

    var onRegisterCallback = function (serverData) {
        var response = JSON.parse(serverData);
        console.log(response);

        if (response.IsSuccess) {
            public.successMessage("You have successfully submitted your registration.");
        } else {
            public.errorMessage("You application has not been accepted.");
        }

        public.isCompleted(true);
    };

    public.register = function () {
        if (public.email() === "") {
            public.errorMessage("Must provide email");
            return;

        } else {
            public.errorMessage("");
        }

        var answers = site.page.objectFactory.convertQuestionsToAnswers(public.challenges());
        var registration = site.page.objectFactory.getRegisterData(public.initiativeId, public.email(), answers);
        site.page.dataAccess.submitAnswers(registration, onRegisterCallback);
    }

    return public;
};


