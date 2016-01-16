require(["knockout", "BugsViewModel", "jquery"], function(ko, BugsViewModel, $){
    $(function(){
        ko.applyBindings(new BugsViewModel());
    });
});
