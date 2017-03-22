function solve() {
    $.fn.datepicker = function() {
        var MONTH_NAMES = ["January", "February", "March", "April",
            "May", "June", "July", "August", "September", "October", "November", "December"
        ];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function() {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function() {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        //################# CALENDAR
        function getCalendarContent(currentDate) {
            var $calendar = $('<table/>')
                .addClass('calendar')

            var headerRow = $('<tr />').appendTo($calendar);
            for (var i = 0, len = WEEK_DAY_NAMES.length; i < len; i++) {
                $('<th />').text(WEEK_DAY_NAMES[i]).appendTo(headerRow);
            }

            var currentMonth = date.getMonth();
            var currentYear = date.getFullYear();
            var curretDay = date.getDay();

            var previousMonth = currentMonth - 1;

            if (previousMonth < 0) {
                previousMonth = 11;
                currentYear -= 1;
            }

            var firstDayOfPreviousMonth = new Date(currentYear, previousMonth, 1);
            var lastDayOfPreviousMonthIndex = new Date(currentYear, previousMonth + 1, 0).getDay();
            var lastDayOfPreviousMonth = daysInMonth(previousMonth + 1, currentYear);
            var firstDayOfCurrentMonth = lastDayOfPreviousMonthIndex + 1;

            if (firstDayOfCurrentMonth > 6) {
                firstDayOfCurrentMonth = 0;
            }

            var row = $('<tr/>').appendTo($calendar);
            var dayNumber = 1;
            var daysToFillFromPreviousMonth = firstDayOfCurrentMonth;
            var previousMonthDayNumber = lastDayOfPreviousMonth - daysToFillFromPreviousMonth + 1;

            //Fill only the first row of current day
            for (var j = 0, len = WEEK_DAY_NAMES.length; j < len; j += 1) {
                if (j < daysToFillFromPreviousMonth) {
                    $('<td/>').addClass('another-month')
                        .text(previousMonthDayNumber).appendTo(row);
                    previousMonthDayNumber += 1;
                } else {
                    $('<td/>').addClass('current-month')
                        .text(dayNumber).appendTo(row);
                    dayNumber += 1;
                }
            }

            //dayNumber = 5 
            //Fill the rest
            var currentDateNumberOfDays = daysInMonth(currentMonth + 1, currentYear);
            var endReached = false;
            var currentRow = 1;

            while (true) {
                currentRow += 1;
                var row = $('<tr/>').appendTo($calendar);
                for (var j = 0, len = WEEK_DAY_NAMES.length; j < len; j += 1) {
                    $('<td/>').addClass('current-month')
                        .text(dayNumber).appendTo(row);

                    dayNumber += 1;

                    if (dayNumber > currentDateNumberOfDays) {
                        if (j <= len - 1) {
                            dayNumber = 1;
                            for (var q = j + 1, len = WEEK_DAY_NAMES.length; q < len; q += 1) {
                                $('<td/>').addClass('another-month')
                                    .text(dayNumber).appendTo(row);
                                dayNumber += 1;
                            }
                        }
                        if (currentRow < 6) {
                            while (currentRow < 6) {
                                currentRow += 1;
                                var row = $('<tr/>').appendTo($calendar);
                                for (var j = 0, len = WEEK_DAY_NAMES.length; j < len; j += 1) {
                                    $('<td/>').addClass('another-month')
                                        .text(dayNumber).appendTo(row);
                                    dayNumber += 1;
                                }
                            }
                        }
                        endReached = true;
                        break;
                    }
                }

                if (endReached) {
                    break;
                }
            }
            return $calendar;
        }
        //################################     

        function daysInMonth(month, year) {
            return new Date(year, month, 0).getDate();
        }

        // you are welcome :)
        var date = new Date();

        var $maindiv = $('div');
        var $input = $('#date').addClass('datepicker');

        var $wrapper = $('<div/>')
            .addClass('datepicker-wrapper')
            .append($input)
            .appendTo($maindiv);

        var $datePickerContent = $('<div/>')
            .addClass('datepicker-content')

        var $controls = $('<div/>')
            .addClass('controls')
            .appendTo($datePickerContent);

        var $buttonLeft = $('<button/>')
            .addClass('btn')
            .text('<')
            .appendTo($controls);

        var $currentMonth = $('<span/>')
            .addClass('current-month')
            .text(date.getMonthName() + ' ' + date.getFullYear())
            .appendTo($controls);

        var $buttonRight = $('<button/>')
            .addClass('btn')
            .text('>')
            .appendTo($controls);

        var $currentStateCalendar = getCalendarContent(date);
        $currentStateCalendar.appendTo($datePickerContent);

        var $currentDate = $('<div/>')
            .addClass('current-date')
            .appendTo($datePickerContent);

        var $currentDateLink = $('<span/>')
            .addClass('current-date-link')
            .text(date.getDay() + ' ' + date.getMonthName() + ' ' + date.getFullYear())
            .appendTo($currentDate);

        var permaDay = date.getDay();
        var permaMonth = date.getMonth();
        var permaFullYear = date.getFullYear();

        $currentDateLink.on('click', function() {
            $input.val(permaDay + '/' + (permaMonth + 1) + '/' + permaFullYear);
        });

        $datePickerContent.on('click', '.current-month', function() {
            $input.val($(this).text() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear());
            $datePickerContent.removeClass('datepicker-content-visible');
        });

        $input.on('click', function() {
            $datePickerContent.addClass('datepicker-content-visible');
        });

        $datePickerContent.on('click', '.another-month', function() {
            var $this = $(this);
            var number = Number($this.text());

            if (number > 16) {
                var currMonth = date.getMonth();
                var currYear = date.getFullYear();
                var currDay = date.getDay();
                var prevMonth = currMonth - 1;

                if (prevMonth < 0) {
                    prevMonth = 11;
                    currYear -= 1;
                }

                date = new Date(currYear, prevMonth);

                $currentMonth.text(date.getMonthName() + ' ' + date.getFullYear());
            } else {
                var currMonth = date.getMonth();
                var currYear = date.getFullYear();
                var currDay = date.getDay();
                var prevMonth = currMonth + 1;

                if (prevMonth > 11) {
                    prevMonth = 0;
                    currYear += 1;
                }

                date = new Date(currYear, prevMonth);
                $currentMonth.text(date.getMonthName() + ' ' + date.getFullYear());
            }


            $currentStateCalendar.remove();
            $currentStateCalendar = getCalendarContent(date);
            $currentStateCalendar.appendTo($datePickerContent);
            $input.val($(this).text() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear());
        });

        $(document).mouseup(function(e) {
            var container = $(".datepicker-wrapper");

            if (!container.is(e.target) // if the target of the click isn't the container...
                &&
                container.has(e.target).length === 0) // ... nor a descendant of the container
            {
                $datePickerContent.removeClass('datepicker-content-visible');
            }
        });

        $controls.on('click', '.btn', function(event) {

            $target = $(event.target);
            if ($target.text() == '<') {
                var currMonth = date.getMonth();
                var currYear = date.getFullYear();
                var currDay = date.getDay();
                var prevMonth = currMonth - 1;

                if (prevMonth < 0) {
                    prevMonth = 11;
                    currYear -= 1;
                }

                date = new Date(currYear, prevMonth);

                $currentMonth.text(date.getMonthName() + ' ' + date.getFullYear());
            } else {
                var currMonth = date.getMonth();
                var currYear = date.getFullYear();
                var currDay = date.getDay();
                var prevMonth = currMonth + 1;

                if (prevMonth > 11) {
                    prevMonth = 0;
                    currYear += 1;
                }

                date = new Date(currYear, prevMonth);

                $currentMonth.text(date.getMonthName() + ' ' + date.getFullYear());
            }

            $currentStateCalendar.remove();
            $currentStateCalendar = getCalendarContent(date);
            $currentStateCalendar.appendTo($datePickerContent);
        });

        $datePickerContent.appendTo($wrapper);

        return this;
    };
};