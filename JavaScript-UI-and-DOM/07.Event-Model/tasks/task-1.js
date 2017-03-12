//BGCODER ES5 - 100/100
//#####################################################################

// function solve() {
    // return function(selector) {
        // if (typeof selector === 'string') {
            // selector = document.getElementById(selector);
            // if (selector == null) {
                // throw Error('selector not found');
            // }
        // } else if (!(selector instanceof HTMLElement)) {
            // throw Error('invalid selector');
        // }

        // var buttons = document.getElementsByClassName('button');
        // var contents = document.getElementsByClassName('content');

        // for (var i = 0; i < buttons.length; i += 1) {
            // buttons[i].textContent = 'hide';
            // buttons[i].addEventListener('click', changeVisibility);
        // }
    // };

    // function changeVisibility(event) {
        // var targetButton = event.target;

        // var targetButtonSibling = findSibling(targetButton);
        // //if we found the correct sibling
        // if (targetButtonSibling != null) {
            // if (targetButtonSibling.style.display == '') {
                // targetButtonSibling.style.display = 'none';
                // targetButton.innerHTML = 'show';
            // } else {
                // targetButtonSibling.style.display = '';
                // targetButton.innerHTML = 'hide';
            // }
        // }
    // }
    // function findSibling(targetEl) {

        // var currentSibling = targetEl.nextElementSibling;

        // if (currentSibling == null ||
            // currentSibling == undefined ||
            // currentSibling.className == 'button') {
            // return null;
        // } else if (currentSibling.className == 'content') {
            // return currentSibling;
        // }

        // findSibling(currentSibling);
    // }
// }
//###############################################################################

//ES6
function solve() {
    return function(selector) {
		
		//if selector is id find find the element and change the value of selector
        if (typeof selector === 'string') {
            selector = document.getElementById(selector);
            if (selector == null) {
                throw Error('selector not found');
            }
        } else if (!(selector instanceof HTMLElement)) {
            throw Error('invalid selector');
        }

        let buttons = document.getElementsByClassName('button');
        let contents = document.getElementsByClassName('content');

        //make buttons to be arry
        buttons = [].slice.apply(buttons);
		
        buttons.forEach(button => {
            button.textContent = 'hide';
            button.addEventListener('click', changeVisibility);
        });
    };

    function changeVisibility(event) {
		
        let targetButton = event.target;
        let targetButtonSibling = findContentSiblingIfExist(targetButton);
		
        //if we found the correct sibling change visibility else do nothing
        if (targetButtonSibling != null) {
            if (targetButtonSibling.style.display == '') {
                targetButtonSibling.style.display = 'none';
                targetButton.innerHTML = 'show';
            } else {
                targetButtonSibling.style.display = '';
                targetButton.innerHTML = 'hide';
            }
        }
    }
	
    function findContentSiblingIfExist(targetEl) {

        let currentSibling = targetEl.nextElementSibling;

        if (currentSibling == null ||
            currentSibling == undefined ||
            currentSibling.className == 'button') {
            return null;
        } else if (currentSibling.className == 'content') {
            return currentSibling;
        }

        findSibling(currentSibling);
    }
}

module.exports = solve;