Create an object and assign it to variable "spinner"

the object should behave like the following

spinner.up(). //=> 1
spinner.up(). //=> 2
spinner.up(). //=> 3

spinnner.down() // => 2
spinnner.down() // => 1
spinnner.down() // => 0
spinnner.down() // => -1


function getSpinner(){
    var count = 0;

    function increment(){
        return ++count;
    }
    function decrement(){
        return --count;
    }
    return {
        up : increment,
        down : decrement
    }
}

var s = getSpinner()
s.up()
s.down()


function Spinner(){
    var count = 0;
    this.up = function(){ return ++count; }
    this.down = function(){ return --count; }
}
