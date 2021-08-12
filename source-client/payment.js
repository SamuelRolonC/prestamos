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
    request.open('GET', 'https://localhost:44347/payment/0', true);

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