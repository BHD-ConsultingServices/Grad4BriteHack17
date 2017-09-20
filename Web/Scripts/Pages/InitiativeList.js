
site.page = function () {
    var public = {};

    public.links = {};
    public.objectFactory = {};
    public.viewModel = {};
    public.dataAccess = {};

    return public;
}();


site.page.objectFactory = function() {
    var public = {};

    var createInitiative = function (original) {
     return {
            title: original.Title,
            description: original.Description,
            redirect: function () { site.page.dataAccess.RedirectToInitiative(original.Id); }
        };
    }

    public.createInitiatives = function(originals) {
        return $.map(originals, createInitiative);
    }

    return public;
}();


site.createViewModel = function (serverData) {
    var public = {};

    var initiativeData = site.page.objectFactory.createInitiatives(serverData.Initiatives);

    console.log("Creating the client side view model.");
    console.log(initiativeData);

    public.initiatives = ko.observable(initiativeData);

    return public;
};


site.page.dataAccess = function () {
    var dal = {};

    dal.RedirectToInitiative = function (id) {
        var redirectUrl = site.page.links.initiativeUrl.replace("{0}", id);

        console.log(redirectUrl);
        window.location = redirectUrl;
    };

    return dal;
}();