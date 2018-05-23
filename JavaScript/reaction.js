document.addEventListener('keydown', function(event) {
    if(event.keyCode == 70) { // F-position
        alert('Left was pressed');
    }
    else if(event.keyCode == 74) { // J-position
        alert('Right was pressed');
    }

})
	
function startRound()
{
var leftStimulus = document.querySelector('#rightStimulus');
leftStimulus.textContent = "Bar";

}
