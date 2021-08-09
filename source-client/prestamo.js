document.addEventListener("DOMContentLoaded", function() {
    getJSON();
});

setActionLoan = (form) => {
    form.action = "";

    // var form = document.querySelector('form');
    var form = document.getElementById("loan")
    var formData = new FormData(form);

    var object = {};
    formData.forEach((value, key) => object[key] = value);
    var json = JSON.stringify(object);
    alert(json);

    return false;
}

getJSON = () => {
    var request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:44347/loan', true);

    request.onload = function() {
        if (request.status >= 200 && request.status < 300) {
            var data = JSON.parse(request.responseText);
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
    
    setValueInput("description", json.loan.description);
    setValueInput("date", getDateForInput(json.loan.loanedDate));
    setValueInput("amount", json.loan.amount);
    setValueSelect("people", json.loan.peopleId);
    setValueSelect("paymentMethod", json.loan.paymentMethodId);
    setValueSelect("term", json.loan.termId);
    setValueInput("comments", json.loan.comments);
    setValueInput("paid", json.paid);
    setValueInput("balance", json.balance);
}