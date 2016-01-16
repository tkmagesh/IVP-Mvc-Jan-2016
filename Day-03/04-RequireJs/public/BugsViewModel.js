 define(["knockout", "BugViewModel", "jquery"], function(ko, BugViewModel, $){
    function BugsViewModel(){
        var self = this;
        self.newBugName = ko.observable();
        self.addNewBug = function(){
            var newBug = {
                id : 0,
                name : self.newBugName(),
                isClosed : false
            };
            $.ajax({
                method : "POST",
                url : "/bugs",
                contentType : "application/json",
                dataType : "json",
                data : JSON.stringify(newBug)
            }).then(function(response){
                self.bugs.push(new BugViewModel(response));
            });
        }
        self.bugs = ko.observableArray();
        fetch("/bugs")
            .then(function(response){
                return response.json();
            })
            .then(function(bugsDataArray){
                bugsDataArray.forEach(function(bugData){
                    self.bugs.push(new BugViewModel(bugData));
                });
            });

    }
    return BugsViewModel;
 });
