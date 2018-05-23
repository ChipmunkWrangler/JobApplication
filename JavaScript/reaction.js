var leftCode = 70; // F-position
var rightCode = 74; // J-position
var hideDelay = 500;
var minShowDelay = 500;
var maxShowDelay = 3000;
var stimulusText = "!!!";

var feedback =     document.querySelector('#feedback');
var leftStimulus = document.querySelector('#leftStimulus');
var rightStimulus = document.querySelector('#rightStimulus');

var timerId;
var stimulusCode = null;

function inputHandler(event) {
    if(event.keyCode === leftCode || event.keyCode === rightCode) {
	handleValidKeypress(event.keyCode);
    } 
}

function handleValidKeypress(keyCode) {
    if (stimulusCode === null) {
	feedback.textContent = "Too soon (or too late)";
    } else if (stimulusCode === keyCode) {
	feedback.textContent = "Right";
    } else {
	feedback.textContent = "Wrong";
    }
    startRound();
}
document.addEventListener('keydown', inputHandler);

function startRound()
{
    clearTimeout(timerId);
    hideStimulus();
    timerId = setTimeout(showStimulus, getShowDelay());
}

function getShowDelay()
{
    var showDelayRange = maxShowDelay - minShowDelay;
    return Math.random() * showDelayRange + minShowDelay;
}

function showStimulus()
{
    var isLeft = Math.random() < 0.5;
    if (isLeft) {
	stimulusCode = leftCode;
	leftStimulus.textContent = stimulusText;
    } else {
	stimulusCode = rightCode;
	rightStimulus.textContent = stimulusText;
    }
    timerId = setTimeout(startRound, hideDelay);
}

function hideStimulus()
{
    stimulusCode = null;
    leftStimulus.textContent = "";
    rightStimulus.textContent = "";
}

startRound();
