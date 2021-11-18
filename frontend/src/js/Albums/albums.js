import api from "../APIcaller/API"
const content=document.getElementById("content");
const title=document.getElementById("title");

export default{
    displayAllAlbums,
}

export function viewAddAlbum()
{

    title.innerText="Add Album";
    content.innerHTML =
    `
    <div class="addPage">
        Title <input type="text" value="" id="album_title" />
        Artist <select id="listArtists"> </select>
        ImageURL <input type="text" value="" id="album_image" />
        Record Label <input type="text" value="" id="album_recordLabel" />
        <button id="btnSaveAlbum">Save Album</button>
    </div>
    `
    const artistsSelectList = document.getElementById("listArtists")

    //populates select list for artist
    api.getRequest("https://localhost:44313/api/artist", artists =>
        {
            artists.forEach(artist =>
            {
                var option = document.createElement("option");
                option.value = artist.id;
                option.text = artist.name;
                artistsSelectList.appendChild(option);
            });
        });
    SetupSaveButton(artistsSelectList)

}

function displayAllAlbums()
{
    title.innerText="Albums";
    api.getRequest("https://localhost:44313/api/album", displayAlbums);
    function displayAlbums(data)
    {
        content.innerHTML =
        `
        <ol>
            ${data.map(album => '<img id="cover"'+album.id+' class="box" src="'+album.image+'"><div id="album"'+album.id+' class="record box"><li>'+album.title+'</li><ul><li> Artist: '+album.artist.name+'</li><li> Record Label: '+album.recordLabel+'</li><li> Songs: '+album.song+'</li><li> Reviews: '+album.review+'</li></ul><button class="editAlbum" albumID='+album.id+'>Edit</button><button class="deleteAlbum" albumID='+album.id+'>Delete</button></div>').join("")}
        </ol>
        <button id="btnAddAlbum">Add Album</button>
        `
        let btnAddAlbum = document.getElementById("btnAddAlbum");
        btnAddAlbum.addEventListener("click", viewAddAlbum);
        let editButtons = Array.from(document.getElementsByClassName("editAlbum"));
        editButtons.forEach(editButton =>
        {
            editButton.addEventListener("click", function()
            {
                let id = editButton.getAttribute("albumID");
                viewEditAlbum(id);
             });
         });
        let deleteButtons = Array.from(document.getElementsByClassName("deleteAlbum"));
        deleteButtons.forEach(deleteButton =>
        {
            deleteButton.addEventListener("click", function()
            {
                let id = deleteButton.getAttribute("albumID");
                console.log(id);
                SetupDeleteAlbum(id);
             });
         });
    }
}

export function SetupSaveButton(selectedArtist)
{
    let btnSave = document.getElementById("btnSaveAlbum");
    btnSave.addEventListener("click", function()
    {
        let albumTitle = document.getElementById("album_title").value;
        let albumImage = document.getElementById("album_image").value;
        let albumRecordLabel = document.getElementById("album_recordLabel").value;

        const Album =
        {
            Title: albumTitle,
            Image: albumImage,
            RecordLabel: albumRecordLabel,
            artistId: selectedArtist.value
        }
        console.log(Album)
        api.postRequest("https://localhost:44313/api/album", Album, displayAllAlbums);
    });
}

function viewEditAlbum(id)
{
    title.innerText = "Edit Album";
    let selectedArtist;
    api.getRequest("https://localhost:44313/api/album/"+id, album =>
        {
            content.innerHTML =
            `
            <div class="editPage">
                Title <input type="text" value="${album.title}" id="album_title" />
                Artist <select id="listArtists"> </select>
                ImageURL <input type="text" value="${album.image}" id="album_image" />
                Record Label <input type="text" value="${album.RecordLabel}" id="album_recordLabel" />
                <button id="btnSaveEdit">Save Album</button>
            </div>
            `
            const artistsSelectList = document.getElementById("listArtists")
            api.getRequest("https://localhost:44313/api/artist", artists =>
            {
                artists.forEach(artist =>
                    {
                        var option = document.createElement("option");
                        option.value = artist.id;
                        option.text = artist.name;
                        if(artist.id==album.artistId)
                            {option.setAttribute("selected","");
                            selectedArtist = album.artistId
                            }
                        artistsSelectList.appendChild(option);
                    });

            });
            let btnSaveEdit = document.getElementById("btnSaveEdit");
            btnSaveEdit.addEventListener("click", function()
            {
                let albumTitle = document.getElementById("album_title").value;
                let albumImage = document.getElementById("album_image").value;
                let albumRecordLabel = document.getElementById("album_recordLabel").value;

                const Album = 
                {
                    Id: id,
                    Title: albumTitle,
                    Image: albumImage,
                    recordLabel: albumRecordLabel,
                    artistId: String(selectedArtist)
                }
                console.log(Album)
                api.putRequest("https://localhost:44313/api/album/",id, Album, displayAllAlbums);
            });
        });    
}

export function SetupDeleteAlbum(id)
{
    api.deleteRequest("https://localhost:44313/api/album/", id, displayAllAlbums);
   
}
