function add(x,y){
   var p = new Promise(function(resolve, reject){
      console.log("processing ", x, " and " , y);
      setTimeout(function(){
         var result = x + y;
         console.log("operation completed");
         resolve(result);
      },3000);
   });
   return p;
}

var p = add(100,200);
p.then(function(result){
    console.log("result = ", result);
});

function deferredAdd(x,y){
    var deferred = Promise.defer();
    console.log("processing ", x, " and " , y);
    setTimeout(function(){
         var result = x + y;
         console.log("operation completed");
         deferred.resolve(result);
    },3000);
    return deferred.promise;
}
