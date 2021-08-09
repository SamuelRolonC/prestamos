populateSelect = (selectId, optionsArray, emptyOption) => {
    if (!Array.isArray(optionsArray)) {
        console.log("Error. Attempt to populate select with a non-Array data.");
        return;
    }
    
    let selectElement = document.getElementById(selectId);

    if (!selectElement) {
        console.log("Error. Select element not found.");
        return;
    }

    optionsArray.unshift({ "id": 0, "text": emptyOption.toString() })
    
    for(let optionElement of optionsArray)
    {
        let opt = document.createElement("option");
        opt.value = optionElement.id;
        opt.innerHTML = optionElement.text;

        selectElement.appendChild(opt);
    }
}

setValueInput = (inputId, text) => {
    let inputElement = document.getElementById(inputId);
    inputElement.value = text;
}

setValueSelect = (selectId, value) => {
    let selectElement = document.getElementById(selectId);
    selectElement.value = value;
}

getDateForInput = (date) => {
    let dateObj = new Date(date)
        , year = dateObj.getFullYear()
        , month = (1 + dateObj.getMonth()).toString().padStart(2, '0')
        , day = dateObj.getDate().toString().padStart(2, '0');
    
    return `${year}-${month}-${day}`;
}