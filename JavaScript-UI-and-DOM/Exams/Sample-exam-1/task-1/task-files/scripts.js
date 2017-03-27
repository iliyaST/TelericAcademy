function createCalendar(selector, events) {

    const DAYS_OF_WEAK = ['Sun', 'Mon', 'Tue', 'Wed', 'Thr', 'Fri', 'Sat'];
    let element = document.querySelector(selector);

    if (events == undefined) {
        events = [];
    }

    if (element == null) {
        throw Error('selector not found');
    }

    let calendar = document.createElement('table');
    calendar.style.borderCollapse = 'collapse'
    let previousTarget;

    let dayCounter = 1;

    for (let i = 0; i < 5; i += 1) {

        let currentRow = document.createElement('tr');

        //check if we are on the last row
        if (i == 4) {

            for (let i = 0; i < 2; i += 1) {

                let currentData = document.createElement('td');
                let currentTitle = document.createElement('div');
                currentTitle.className = 'title-calendar';
                let currentContent = document.createElement('div');
                currentContent.className = 'content-calendar-data';


                currentTitle.style.with = 130 + 'px';
                currentContent.style.with = 130 + 'px';
                currentTitle.style.height = 20 + 'px';
                currentContent.style.height = 80 + 'px';

                currentTitle.style.borderBottom = '2px solid #222222';
                currentTitle.style.backgroundColor = '#CCCCCC';
                currentTitle.style.margin = '0px';
                currentTitle.style.padding = '0px';

                currentData.appendChild(currentTitle);
                currentData.appendChild(currentContent);

                currentData.width = 130 + 'px';
                currentData.height = 100 + 'px';
                currentData.style.border = '2px solid #222222';
                currentData.style.padding = '0px';

                currentTitle.innerHTML = DAYS_OF_WEAK[i] + ' ' + dayCounter + ' June 2014';
                currentContent.setAttribute('data-info', dayCounter);
                currentTitle.style.textAlign = 'center';


                dayCounter += 1;
                currentRow.appendChild(currentData);
            }

            calendar.appendChild(currentRow);
            break;
        }

        for (let i = 0; i < 7; i += 1) {
            let currentData = document.createElement('td');
            let currentTitle = document.createElement('div');
            currentTitle.className = 'title-calendar';
            let currentContent = document.createElement('div');
            currentContent.className = 'content-calendar-data';

            currentTitle.style.with = 130 + 'px';
            currentContent.style.with = 130 + 'px';
            currentTitle.style.height = 20 + 'px';
            currentContent.style.height = 80 + 'px';

            currentTitle.style.borderBottom = '2px solid #222222';
            currentTitle.style.backgroundColor = '#CCCCCC';
            currentTitle.style.margin = '0px';
            currentTitle.style.padding = '0px';

            currentData.appendChild(currentTitle);
            currentData.appendChild(currentContent);

            currentData.width = 130 + 'px';
            currentData.height = 100 + 'px';
            currentData.style.border = '2px solid #222222';
            currentData.style.padding = '0px';

            currentTitle.innerHTML = DAYS_OF_WEAK[i] + ' ' + dayCounter + ' June 2014';
            currentContent.setAttribute('data-info', dayCounter);
            currentTitle.style.textAlign = 'center';

            dayCounter += 1;

            currentRow.appendChild(currentData);
        }

        calendar.appendChild(currentRow);
    }

    calendar.addEventListener('mouseover', function(event) {

        let target = event.target;

        if (target.className == 'title-calendar') {
            target.style.backgroundColor = '#6B8E23';
        }
    });

    calendar.addEventListener('mouseout', function(event) {

        let target = event.target;

        if (target.className == 'title-calendar') {
            target.style.backgroundColor = '#CCC';
        }
    });

    calendar.addEventListener('click', function(event) {
        let target = event.target;

        if (target.className == 'content-calendar-data') {

            if (target.style.backgroundColor == 'rgb(154, 205, 50)') {
                target.style.backgroundColor = 'white';
            } else {

                if (previousTarget != undefined) {
                    previousTarget.style.backgroundColor = 'white';
                }

                target.style.backgroundColor = '#9ACD32';
                previousTarget = target;
            }
        }
    });

    let allDaysSelected = [].slice.apply(calendar.getElementsByClassName('content-calendar-data'));

    events.forEach(event => {
        let getCurrentTitle = event.title;
        let getCurrentDate = event.date;
        let getCurrentHour = event.hour;
        let duration = event.duration;

        allDaysSelected.forEach(date => {
            if (date.getAttribute("data-info") == getCurrentDate) {
                date.innerHTML = getCurrentHour + ' ' + getCurrentTitle;
            }
        });

        element.appendChild(calendar);
        //let eventDate = document.getElementsByClassName(getCurrentDate)[0];
        //eventDate.innerHTML = getCurrentHour + ' ' + getCurrentTitle;
    });
}