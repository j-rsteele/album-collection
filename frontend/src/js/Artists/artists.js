import api from "../APIcaller/API"
const content=document.getElementById("content");
const title=document.getElementById("title");

export default{
    display,
}

function display(){
    title.innerText="Artist";
    api.getRequest("https://localhost:44313/api/artist", displayArtist);

    function displayArtist(data)
    {
        content.innerHTML = 
        `
        <ol>
            ${data.map(artist => "<li> Name: "+artist.name+"</li><ul><li> Record Label: "+artist.recordLabel+"</li><li> Hometown: "+artist.hometown+"</li><li> Age: "+artist.age+"</li></ul>").join(" ")}
        </ol>
        `
    }
}