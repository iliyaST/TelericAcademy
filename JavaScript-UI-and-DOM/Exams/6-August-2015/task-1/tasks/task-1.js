function solve() {
    return function(selector, isCaseSensitive) {
        var element = document.querySelector(selector);
        element.className += 'items-control';

        if (isCaseSensitive == undefined) {
            isCaseSensitive = false;
        }

        var addControls = document.createElement('div');
        addControls.className += 'add-controls';
        var addControlsLabel = document.createElement('label');
        addControlsLabel.innerHTML = 'Enter text';
        var addControlsInput = document.createElement('input');
        addControlsInput.className = "add-controls-input";
        var addControlsButton = document.createElement('button');
        addControlsButton.className = "button";
        addControlsButton.innerHTML = "Add";
        addControls.appendChild(addControlsLabel);
        addControls.appendChild(addControlsInput);
        addControls.appendChild(addControlsButton);

        var searchControls = document.createElement('div');
        searchControls.className = 'search-controls';
        var searchControlsLabel = document.createElement('label');
        searchControlsLabel.innerHTML = 'Search:';
        var searchControlsInput = document.createElement('input');
        searchControlsInput.className = 'search-controls-input';
        searchControls.appendChild(searchControlsLabel);
        searchControls.appendChild(searchControlsInput);

        var resultControls = document.createElement('div');
        resultControls.className = 'result-controls';
        var resultControlsItemsList = document.createElement('ul');
        resultControlsItemsList.className += 'items-list';
        resultControls.appendChild(resultControlsItemsList);

        element.appendChild(addControls);
        element.appendChild(searchControls);
        element.appendChild(resultControls);

        addControlsButton.addEventListener('click', function() {
            var newListItem = document.createElement('li');
            newListItem.className = 'list-item';
            var delButton = document.createElement('button');
            delButton.className = 'button';
            delButton.innerHTML = 'X';
            var listContent = document.createElement('span');
            listContent.className = 'text-content';
            listContent.innerHTML = addControlsInput.value;

            newListItem.appendChild(listContent);
            newListItem.appendChild(delButton);

            newListItem.style.display = 'none';
            resultControlsItemsList.appendChild(newListItem);
        });

        searchControlsInput.addEventListener('input', function() {
            var contents = resultControlsItemsList.getElementsByClassName('list-item'),
                i = 0;

            if (searchControlsInput.value != '') {
                for (i = 0; i < contents.length; i += 1) {
                    var currentList = contents[i];
                    var currentListText = currentList.getElementsByClassName('text-content')[0];

                    if (isCaseSensitive) {
                        if (currentListText.innerHTML.includes(searchControlsInput.value)) {
                            currentList.style.display = '';
                        }
                    } else {
                        if (currentListText.innerHTML.toLocaleLowerCase()
                            .includes(searchControlsInput.value.toLowerCase())) {
                            currentList.style.display = '';
                        }
                    }
                }
            } else {
                for (i = 0; i < contents.length; i += 1) {
                    var currentList = contents[i];
                    currentList.style.display = 'none';
                }
            }
        });

        resultControls.addEventListener('click', function(event) {
            if (event.target.className == 'button') {
                var parent = event.target.parentElement;
                resultControlsItemsList.removeChild(parent);
            }
        });
    };
}

module.exports = solve;