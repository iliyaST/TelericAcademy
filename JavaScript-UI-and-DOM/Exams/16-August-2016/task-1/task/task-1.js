/* globals document, window, console */

function solve() {
    return function(selector, initialSuggestions) {

        var element = document.querySelector(selector);
        var suggestionsList = document.getElementsByClassName('suggestions-list')[0];
        var input = document.getElementsByClassName('tb-pattern')[0];
        var addButton = document.getElementsByClassName('btn-add')[0];
        var uniqNamesSuggestions = [];

        if (initialSuggestions == undefined) {
            initialSuggestions = [];
        }

        //get uniq names
        for (var suggestionName of initialSuggestions) {
            if (uniqNamesSuggestions.length > 0) {
                var foundSameElement = false;
                for (var el of uniqNamesSuggestions) {
                    if (el.toLowerCase() == suggestionName.toLowerCase()) {
                        foundSameElement = true;
                        break;
                    }
                }

                if (foundSameElement == false) {
                    uniqNamesSuggestions.push(suggestionName);
                }
            } else {
                uniqNamesSuggestions.push(suggestionName);
            }
        }

        //append inital suggestions to suggestion list
        for (var suggestionName of uniqNamesSuggestions) {
            suggestionsList.appendChild(createSuggestion(suggestionName));
        }

        input.addEventListener('input', function() {
            var textInput = this.value.toLowerCase();
            var suggestions = element.getElementsByClassName('suggestion');

            //hide initialy
            if (textInput == '') {
                suggestionsList.style.display = 'none';
                return;
            }

            suggestionsList.style.display = '';

            //find suggestions that match requirments
            for (var i = 0; i < suggestions.length; i += 1) {
                linkInSuggestion = suggestions[i].getElementsByClassName("suggestion-link")[0];
                var linkInSuggestionName = linkInSuggestion.innerHTML.toLowerCase();

                if (linkInSuggestionName.indexOf(textInput) >= 0) {
                    suggestions[i].style.display = '';
                } else {
                    suggestions[i].style.display = 'none';
                }
            }
        });

        element.addEventListener('click', function(event) {
            if (event.target.className == 'suggestion-link') {
                input.value = event.target.innerHTML;
            }
        });

        addButton.addEventListener('click', function() {
            var inputValueText = input.value;
            var foundSameSuggestion = false;
            var suggestions = element.getElementsByClassName('suggestion');

            for (i = 0; i < suggestions; i += 1) {
                var currentLink = suggestions[i].getElementsByClassName('suggestion-link');
                if (currentLink.innerHTML.toLowerCase == inputValueText.toLowerCase()) {
                    foundSameSuggestion = true;
                    break;
                }
            }

            if (foundSameSuggestion == false) {
                suggestionsList.appendChild(createSuggestion(inputValueText));
            }
        });

        //function for creating suggestions in format described
        function createSuggestion(name) {
            var suggestion = document.createElement('li');
            suggestion.className = 'suggestion';
            var link = document.createElement('a');
            link.className = 'suggestion-link';
            link.href = '#';
            link.textContent = name;
            suggestion.appendChild(link);
            suggestion.style.display = 'none';
            return suggestion;
        }
    };
}

module.exports = solve;