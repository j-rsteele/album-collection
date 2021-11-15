export default{
    putRequest,
    deleteRequest,
    getRequest,
    postRequest
}

function putRequest(location, id, requestBody, callback){
    fetch(`${location}${id}`, {
        method: "PUT",
        headers: {
            "Content-Type" : "application/json"
        },
        body: JSON.stringify(requestBody)
    })
    .then(response => response.json())
    .then(data => {
        callback(data);
    })
    .catch(err => console.log(err));
}

function deleteRequest(location, id, callback){
    fetch(`${location}${id}`, {
        method: "DELETE",
        headers: {
            "Content-Type" : "application/json"
        }
    })
    .then(response => response.json())
    .then(data => {
        callback(data);
    })
    .catch(err => console.log(err));
}

function getRequest(location, callback){
    fetch(location)
    .then(response => response.json())
    .then(data => {
        callback(data);
    })
    .catch(err => console.log(err));
}

function postRequest(location, requestBody, callback){
    fetch(`${location}`, {
        method: "POST",
        headers: {
            "Content-Type" : "application/json"
        },
        body: JSON.stringify(requestBody)
    })
    .then(response => response.json())
    .then(data => {
        callback(data);
    })
    .catch(err => console.log(err));
}
