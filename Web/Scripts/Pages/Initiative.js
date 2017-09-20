var challengeTypeEnum = { Undefined: 0, YesNo: 1, MultiChoice: 2 }

site.page = function () {
    var public = {};

    public.links = {};
    public.objectFactory = {};
    public.viewModel = {};
    public.dataAccess = {};

    return public;
}();


site.page.objectFactory = function () {
    var public = {};

    var createChallenge = function (original) {
        var converted = {};

        converted.question = original.Question;
        converted.type = original.Type;

        var hasMulti = original.Type === challengeTypeEnum.MultiChoice;

        converted.optionA = hasMulti ? original.MultiChoiceChallenge.OptionA : "";
        converted.optionB = hasMulti ? original.MultiChoiceChallenge.OptionB : "";
        converted.optionC = hasMulti ? original.MultiChoiceChallenge.OptionC : "";
        converted.optionD = hasMulti ? original.MultiChoiceChallenge.OptionD : "";

        converted.answer = ko.observable(undefined);

        converted.answer.subscribe(function () {
            var counter = 0;

            $.each(site.page.viewModel.challenges(), function (key, value) {
                if (value.answer() != undefined && value.answer() !== "") {
                    counter++;
                }
            });

            site.page.viewModel.numberOfCompleted(counter);
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

    public.yesNoOptions = ko.observableArray([{ label: "Undefined", value: "" }, { label: "Yes", value: "Yes" }, { label: "No", value: "No" }]);
    public.challenges = ko.observableArray(challengeData);

    public.numberOfCompleted = ko.observable(0);

    public.numberOfQuestions = ko.computed(function () {
        return public.challenges().length;
    });

    return public;
};


site.page.dataAccess = function () {
    var dal = {};

    dal.SubmitAnswers = function (challenge) {
        console.log(challenge);
    };

    return dal;
}();