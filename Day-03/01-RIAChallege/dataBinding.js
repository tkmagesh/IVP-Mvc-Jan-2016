var dataBinding = (function(){
        var observable = function(defaultValue){
             var _value = defaultValue;
             var _subscribers = [];
             var fn = function(val){
                 if (arguments.length === 0) return _value;
                 _value = val;
                 _subscribers.forEach(function(subscriber){
                     subscriber.call(this, _value);
                 });
             };
             fn.subscribe = function(subscriptionFn){
                 _subscribers.push(subscriptionFn);
             };
             return fn;
        };
        function applyBinding(calculator){
            $("*[data-value]").each(function(index, element){
                var $element = $(element);
                var modelAttribute = $element.attr("data-value");

                $element.change(function(){
                    calculator[modelAttribute](this.value);
                });

                calculator[modelAttribute].subscribe(function(value){
                    $element.val(value);
                });
            });

            $("*[data-text]").each(function(index, element){
                var $element = $(element);
                var modelAttribute = $element.attr("data-text");
                calculator[modelAttribute].subscribe(function(value){
                    $element.html(value);
                });
            });

            $("*[data-click]").each(function(index, element){
                var $element = $(element);
                var modelAttribute = $element.attr("data-click");
                $element.click(function(){
                    calculator[modelAttribute]();
                });
            });
        }

        return {
            observable : observable,
            applyBinding : applyBinding
        }
    })();
