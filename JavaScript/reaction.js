leftCode = 70; // F-position
rightCode = 74; // J-position
stimulusCode = undefined;
var feedback =     document.querySelector('#feedback');
var leftStimulus = document.querySelector('#leftStimulus');
var rightStimulus = document.querySelector('#rightStimulus');
function inputHandler(event) {
    if(event.keyCode === leftCode || event.keyCode === rightCode) {
	handleValidKeypress(event.keyCode);
    } 
}

function handleValidKeypress(keyCode) {
    if (stimulusCode === undefined) {
	feedback.textContent = "Too soon (or too late)";
    } else if (stimulusCode === keyCode) {
	feedback.textContent = "Right";
    } else {
	feedback.textContent = "Wrong";
    }
}
document.addEventListener('keydown', inputHandler);

function startRound()
{

}
