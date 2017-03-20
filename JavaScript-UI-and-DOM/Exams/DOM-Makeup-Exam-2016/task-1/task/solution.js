function solve() {
    return function(selector, tabs) {
        var element = document.querySelector(selector);
        var targetIndex;
        var previousTarget;
        var textArea;
        var ulNav = document.createElement('ul');
        var ulContent = document.createElement('ul');
        ulContent.className = 'tabs-content';
        ulNav.className = 'tabs-nav';

        tabs.forEach(function(tab, index) {
            var liNav = document.createElement('li');
            var aNav = document.createElement('a');
            var liContent = document.createElement('li');
            var pContent = document.createElement('p');
            var editButton = document.createElement('button');

            aNav.setAttribute('index', index);
            aNav.className = 'tab-link';
            aNav.innerHTML = tab.title;
            liNav.appendChild(aNav);
            ulNav.appendChild(liNav);

            liContent.setAttribute('index', index);
            liContent.className = 'tab-content';
            editButton.className = 'btn-edit';
            editButton.innerHTML = 'Edit';
            pContent.innerHTML = tab.content;
            liContent.appendChild(pContent);
            liContent.appendChild(editButton);
            ulContent.appendChild(liContent);
        });

        ulContent.firstChild.className += ' visible';
        previousTarget = ulContent.firstChild.getElementsByTagName('p')[0];
        targetIndex = 0;

        element.addEventListener('click', function(event) {
            var target = event.target,
                contents = document.querySelectorAll('.tab-content');

            if (target.className == 'tab-link') {
                document.querySelector('.tab-content.visible')
                    .classList.remove('visible');
                targetIndex = target.getAttribute('index');
                contents[targetIndex].className += ' visible';
                previousTarget = contents[targetIndex].firstChild;
            }

            if (target.className == 'btn-edit') {
                if (target.innerHTML == 'Edit') {
                    textArea = document.createElement('textarea');
                    textArea.className = 'edit-content';
                    target.innerHTML = 'Save';
                    textArea.value = previousTarget.innerHTML;
                    contents[targetIndex].appendChild(textArea);
                } else {
                    previousTarget.innerHTML = textArea.value;
                    contents[targetIndex].removeChild(textArea);
                    target.innerHTML = 'Edit';
                }
            }
        });

        element.appendChild(ulNav);
        element.appendChild(ulContent);
    }
}

// submit the above!

if (typeof module !== 'undefined') {
    module.exports = solve;
}