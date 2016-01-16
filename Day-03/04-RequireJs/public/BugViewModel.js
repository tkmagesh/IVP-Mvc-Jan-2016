define("BugViewModel", ["knockout"], function(ko){
    function BugViewModel(defaults){
        var self = this;
        self.id = ko.observable(defaults.id);
        self.name = ko.observable(defaults.name);
        self.isClosed = ko.observable(defaults.isClosed);
    }
    BugViewModel.prototype.toggle = function(){
        this.isClosed(!this.isClosed());
    };
    return BugViewModel;
});
