document.addEventListener("DOMContentLoaded", function() {
    let grid = new gridjs.Grid({
        columns:  [ "Prestamo","Persona","Fecha de pago","Medio de pago", "Importe"
            ,"Restante" ],
        data: () => {
            return new Promise(resolve => {
                setTimeout(() =>
                resolve([
                    ["Dirk", "dborkett0@com.com", "(646) 3432270", "Male"],
                    ["Maryl", "mchampkins1@dailymail.co.uk", "(980) 3335235", "Female"],
                    ["Stefan", "sbrawson2@smh.com.au", "(180) 3533257", "Male"],
                    ["Stephanie", "scouronne4@storify.com", "(904) 5358792", "Female"],
                    ["Emeline", "esooley5@cyberchimps.com", "(308) 6561908", "Female"],
                    ["Gavra", "gkrout9@foxnews.com", "(383) 4909639", "Female"],
                    ["Roxi", "rvillage1@businessweek.com", "(980) 3335235", "Male"],
                    ["Jamey", "jsheringham0@rakuten.co.jp", "(773) 5233571", "Male"],
                    ["Maye", "mambrosoni8@prweb.com", "(895) 9997017", "Female"]
                ]), 2000);
            });
        },
        search: true,
        sort: true,
        pagination: {
            limit: 5
        },        
    }).render(document.getElementById("tablePayment"))

    getJSON();
});

setActionPayment = (form) => {
    let formData = new FormData(form)
        , object = {};
    
    form.action = "";
        
    formData.forEach((value, key) => object[key] = value);
    let json = JSON.stringify(object);
    alert(json);

    return false;
}

getJSON = () => {
    let request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:44347/payment', true);

    request.onload = function() {
        if (request.status < 200 && request.status >= 300) {
            alert(`${request.status}. ${request.responseText}`);
        }

        let data = JSON.parse(request.responseText);
        populateData(data);
    };

    request.onerror = function() {
        
    };

    request.send();
}

populateData = (json) => {
    if (!json) return;
    
    emptyOptionSeleccione = "Seleccione";
    
    populateSelect("people", json.listPeople, emptyOptionSeleccione);
    populateSelect("paymentMethod", json.listPaymentMethod, emptyOptionSeleccione);
    populateSelect("loan", json.listLoan, emptyOptionSeleccione);
    
    setValueInput("description", json.payment.description);
    setValueInput("date", getDateForInput(json.payment.paidDate));
    setValueInput("amount", json.payment.amount);
    setValueInput("paid", json.paid);
    setValueInput("balance", json.balance);
    setValueSelect("people", json.payment.peopleId);
    setValueSelect("paymentMethod", json.payment.paymentMethodId);
    setValueInput("comments", json.payment.comments);
}