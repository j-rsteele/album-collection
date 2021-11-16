import api from "../APIcaller/API"
const content=document.getElementById("content");
const title=document.getElementById("title");

export default{
    display,
}

function display()
{
    title.innerText="Albums";
    api.getRequest("https://localhost:44313/api/album", displayAlbums);
    
    function displayAlbums(data)
    {
        content.innerHTML = 
        `
        <ol>
            ${data.map(album => "<li> Title: "+album.title+"</li>").join("")}
        </ol>
        `
    }
}


