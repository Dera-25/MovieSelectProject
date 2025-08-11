const movieBaseUrl = "https://localhost:7039/api/movies";
const genreBaseUrl = "https://localhost:7039/api/genres";

// ====== MOVIE FUNCTIONS ======
// Hide/Show all movies
function toggleMovies() {
    const isHidden = window.getComputedStyle(allMoviesSection).display === "none";
    allMoviesSection.style.display = isHidden ? "block" : "none";
}
// Load all movies
function loadMovies() {
    fetch(movieBaseUrl)
        .then(res => res.json())
        .then(movies => {
            const movieList = document.getElementById("movieList");
            movieList.innerHTML = "";
            movies.forEach(m => {
                const li = document.createElement("li");
                li.textContent = `ID: ${m.id} - ${m.title} (${m.ageRating}) ${m.genre}`;
                movieList.appendChild(li);
            });
        });
}

// Add movie
function addMovie(e) {
    e.preventDefault();
    const movie = {
        title: document.getElementById("addTitle").value,
        genreId: parseInt(document.getElementById("addGenreSelect").value),
        ageRating: document.getElementById("addAgeRating").value
    };
    fetch(movieBaseUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(movie)
    }).then(() => {
        loadMovies();
        e.target.reset();
    });
}

function clearAddMovie() {
    document.getElementById("addTitle").value = "";
    document.getElementById("addGenreSelect").value = "";
    document.getElementById("addAgeRating").value = "";
}

// Update movie
function updateMovie(e) {
    e.preventDefault();
    const id = parseInt(document.getElementById("updateId").value);
    const movie = {
        id,
        title: document.getElementById("updateTitle").value || undefined,
        genreId: document.getElementById("updateGenreSelect").value ? parseInt(document.getElementById("updateGenreSelect").value) : undefined,
        ageRating: document.getElementById("updateAgeRating").value || undefined
    };
    fetch(`${movieBaseUrl}/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(movie)
    }).then(() => {
        loadMovies();
        e.target.reset();
    });
}
// Clear update form
function clearUpdate() {
    document.getElementById("updateMovieForm").reset();
}

// Get movie by ID
function getMovieById(e) {
    e.preventDefault();
    const id = parseInt(document.getElementById("getMovieId").value);
    fetch(`${movieBaseUrl}/${id}`)
        .then(res => {
            if (!res.ok) throw new Error("Movie not found");
            return res.json();
        })
        .then(m => {
            document.getElementById("movieResult").textContent = `ID: ${m.id} - ${m.title} (${m.ageRating}) ${m.genre}`;
        })
        .catch(() => {
            document.getElementById("movieResult").textContent = "Movie not found";
        });
}
// Clear movie result
function clearMovieResult() {
    document.getElementById("movieResult").textContent = "";
    document.getElementById("getMovieId").value = "";
}

// Delete movie
function deleteMovie(e) {
    e.preventDefault();
    const id = parseInt(document.getElementById("deleteMovieId").value);
    fetch(`${movieBaseUrl}/${id}`, { method: "DELETE" })
        .then(() => loadMovies());
}

// Get genre of a movie
function getGenreOfMovie(e) {
    e.preventDefault();
    const movieId = parseInt(document.getElementById("movieGenreId").value);
    fetch(`${movieBaseUrl}/${movieId}`)
        .then(res => res.json())
        .then(m => {
            document.getElementById("movieGenreResult").textContent = `Genre: ${m.genre}` ;
        });
}
//Clear movie genre result
function clearMovieGenre() {
    document.getElementById("movieGenreResult").textContent = "";
    document.getElementById("movieGenreId").value = "";
}

// ====== GENRE FUNCTIONS ======

// Load genres into dropdowns
function loadGenres() {
    fetch(genreBaseUrl)
        .then(res => res.json())
        .then(genres => {
            const options = genres.map(g => `<option value="${g.id}">${g.name}</option>`).join("");
            document.getElementById("addGenreSelect").innerHTML = `<option value="">Select Genre</option>${options}`;
            document.getElementById("updateGenreSelect").innerHTML = `<option value="">Select Genre</option>${options}`;
            document.getElementById("genreSelectForMovies").innerHTML = `<option value="">-- Select Genre --</option>${options}`;
        });
}

// Get all genres
function getAllGenres() {
    fetch(genreBaseUrl)
        .then(res => res.json())
        .then(data => {
            const container = document.getElementById("genresList");
            container.innerHTML = "<ul>" + data.map(g => `<li>${g.id}: ${g.name}</li>`).join('') + "</ul>";
        });
}
//Clear genres
function clearGenresList() {
    document.getElementById("genresList").innerHTML = "";
}

// Get movies by genre
function getMoviesByGenre() {
    const genreId = document.getElementById("genreSelectForMovies").value; 
    if (!genreId) {
        alert("Please select a genre first");
        return;
    }

    fetch(`${movieBaseUrl}/genre/${genreId}`)
        .then(res => {
            if (!res.ok) throw new Error("No movies found for this genre");
            return res.json();
        })
        .then(movies => {
            const container = document.getElementById("moviesByGenreList");
            container.innerHTML = "";

            if (movies.length === 0) {
                container.textContent = "No movies found in this genre.";
                return;
            }

            const ul = document.createElement("ul");
            movies.forEach(m => {
                const li = document.createElement("li");
                li.textContent = `${m.title} (${m.ageRating})`;
                ul.appendChild(li);
            });
            container.appendChild(ul);
        })
        .catch(err => console.error("Error fetching movies:", err));
}

function clearMoviesByGenre() {
    document.getElementById("moviesByGenreList").innerHTML = "";
    document.getElementById("genreSelectForMovies").value = "";
}

// Add genre
function addGenre(event) {
    event.preventDefault();
    const name = document.getElementById("newGenreName").value.trim();
    if (!name) return alert("Genre name is required!");

    fetch(genreBaseUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name })
    })
    .then(res => {
        if (res.ok) {
            document.getElementById("newGenreName").value = "";
            getAllGenres();       // refresh the genre list display
            loadGenres();         // refresh dropdowns for movie forms
            loadGenresForMovies(); // refresh dropdown for "movies in genre"
        } else {
            alert("Failed to add genre");
        }
    })
    .catch(err => console.error("Error adding genre:", err));
    
}

// Update genre
function updateGenre() {
    const id = document.getElementById("updateGenreId").value;
    const name = document.getElementById("updateGenreName").value.trim();
    if (!id || !name) return alert("Both ID and name are required!");

    fetch(`${genreBaseUrl}/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name })
    }).then(res => res.ok ? getAllGenres() : alert("Failed to update genre"));
}

// Delete genre
function deleteGenre() {
    const id = document.getElementById("deleteGenreId").value;
    if (!id) return alert("Genre ID required!");

    fetch(`${genreBaseUrl}/${id}`, { method: "DELETE" })
        .then(res => res.ok ? getAllGenres() : alert("Failed to delete genre"));
}

loadGenres();
loadMovies();


// function clearMovieResult() {
//     document.getElementById("movieResult").innerHTML = "";
//     document.getElementById("getMovieForm").reset();
    
// }
// function clearMovieGenre() {
//     document.getElementById("movieGenreResult").innerHTML = "";
//     document.getElementById("getGenreMovieForm").reset();
    
// }
