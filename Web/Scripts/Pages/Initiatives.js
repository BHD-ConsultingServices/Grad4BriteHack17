site.page = function () {
    var public = {};

    public.Links = {};
    public.objectFactory = {};
    public.viewModel = {};
    public.dataAccess = {};

    return public;
}();


site.page.objectFactory = function() {
    var public = {};

    var createInitiative = function(original) {
        return {
            title: original.Title,
            description: original.Description
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