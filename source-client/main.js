populateSelect = (selectId, optionsArray, emptyOption) => {
    let list = [{ "id": 0, "text": emptyOption.toString() }];

    if (Array.isArray(optionsArray)) {
        list = list.concat(optionsArray);
    }
    
    let selectElement = document.getElementById(selectId);

    if (!selectElement) {
        console.log("Error. Select element not found.");
        return;
    }

    for(let item of list)
    {
        let opt = document.createElement("option");
        opt.value = item.id;
        opt.innerHTML = item.text;

        selectElement.appendChild(opt);
    }
}

setValueInput = (inputId, text) => {
    let inputElement = document.getElementById(inputId);

    if (inputElement)
        inputElement.value = text;
}

setValueSelect = (selectId, value) => {
    let selectElement = document.getElementById(selectId);
    
    if (selectElement)
        selectElement.value = value;
}

getDateForInput = (date) => {
    let dateObj = new Date(date)
        , year = dateObj.getFullYear()
        , month = (1 + dateObj.getMonth()).toString().padStart(2, '0')
        , day = dateObj.getDate().toString().padStart(2, '0');
    
    return `${year}-${month}-${day}`;
}