document.addEventListener("DOMContentLoaded", function() {
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
        if (request.status >= 200 && request.status < 300) {
            let data = JSON.parse(request.responseText);
            populateData(data);
        } else {
            alert(`${request.status}. ${request.responseText}`);
        }
    };

    request.onerror = function() {
    // There was a connection error of some sort
    };

    request.send();
}

populateData = (json) => {
    emptyOptionSeleccione = "Seleccione";
    
    populateSelect("people", json.listPeople, emptyOptionSeleccione);
    populateSelect("paymentMethod", json.listPaymentMethod, emptyOptionSeleccione);
    populateSelect("term", json.listTerm, emptyOptionSeleccione);
    
    setValueInput("description", json.payment.description);
    setValueInput("date", getDateForInput(json.payment.paidDate));
    setValueInput("amount", json.payment.amount);
    setValueInput("paid", json.paid);
    setValueInput("balance", json.balance);
    setValueSelect("people", json.payment.peopleId);
    setValueSelect("paymentMethod", json.payment.paymentMethodId);
    setValueInput("comments", json.payment.comments);
}