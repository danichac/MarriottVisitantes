    
window.addEventListener('DOMContentLoaded', event => {

    const fechaHidden = document.getElementById('fechaHidden');
    const litepickerSingleDate = document.getElementById('litepickerSingleDate');
    if (litepickerSingleDate) {
        const picker = new Litepicker({
            element: litepickerSingleDate,
            format: 'DD/MM/YYYY',
            lang: 'es'
        });

        picker.on('selected', (date1) => {
            fechaHidden.setAttribute('value', date1.toLocaleString('en-US', { timeZone: 'UTC' }));
        });
    }
    

    const litepickerDateRange = document.getElementById('litepickerDateRange');
    if (litepickerDateRange) {
        new Litepicker({
            element: litepickerDateRange,
            singleMode: false,
            format: 'MMM DD, YYYY'
        });
    }

    const litepickerDateRange2Months = document.getElementById('litepickerDateRange2Months');
    if (litepickerDateRange2Months) {
        new Litepicker({
            element: litepickerDateRange2Months,
            singleMode: false,
            numberOfMonths: 2,
            numberOfColumns: 2,
            format: 'MMM DD, YYYY'
        });
    }
});
