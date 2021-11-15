import api from "../APIcaller/API"
const content=document.getElementById("content");
const title=document.getElementById("Title");
title.innerText="Albums";

api.getRequest("https://localhost:44313/api/artist",displayAlbums(data))
function displayAlbums(data)
{
    content.innerHTML = `
        <ol>
        </ol>
    
    `
}

