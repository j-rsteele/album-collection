import albums from "./Albums/albums";
import artists from "./Artists/artists";
const navArtists=document.getElementById("navArtists");
const navAlbums=document.getElementById("navAlbums");

export default() => {
    navAlbums.addEventListener("click", albums.displayAllAlbums)
    navArtists.addEventListener("click",artists.viewArtists)
    artists.viewArtists();
}

