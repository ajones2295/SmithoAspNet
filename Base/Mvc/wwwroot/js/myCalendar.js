var eventData = [];

// get events button 


document.addEventListener('DOMContentLoaded', function () {
    //eventData = myEventData;
    ////FetchEvents();
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        initialDate: '2022-02-02',
        timeZone: 'local',
        events: eventData
    });
    console.log(eventData);
    calendar.render();
});


const myEventData = function FetchEvents() {
    var token = 'bearer ' + sessionStorage.getItem('accessToken');
    eventData = [];
    $.ajax({
        type: "GET",
        accepts: "application/json",
        headers: {
            Authorization: token
        },
        url: "https://localhost:5001/api/Calendar/ViewPendingEvents",
        success: function (data) {
            $.each(data, function (i, v) {
                eventData.push({
                    eventId: v.EventId,
                    title: v.Title,
                    description: v.Description,
                    start: v.StartDate,
                    end: v.EndDate != null ? v.EndDate : null
                });
            })
        },
        error: function (error) {
            alert('failed fetching events');
            console.log(error);
        }
    })
}