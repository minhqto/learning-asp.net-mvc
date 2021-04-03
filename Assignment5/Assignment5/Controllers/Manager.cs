// **************************************************
// WEB524 Project Template V2 == 063abf5d-817d-4878-befb-eaf02eb3adaa
// Do not change this header.
// **************************************************

using Assignment5.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Assignment5.EntityModels;
namespace Assignment5.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // AutoMapper instance
        public IMapper mapper;

        // Request user property...

        // Backing field for the property
        private RequestUser _user;

        // Getter only, no setter
        public RequestUser User
        {
            get
            {
                // On first use, it will be null, so set its value
                if (_user == null)
                {
                    _user = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);
                }
                return _user;
            }
        }

        // Default constructor...
        public Manager()
        {
            // If necessary, add constructor code here

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();

                cfg.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();
                cfg.CreateMap<Artist, ArtistBaseViewModel>();
                cfg.CreateMap<Album, AlbumBaseViewModel>();
                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Genre, GenreBaseViewModel>();
                cfg.CreateMap<ArtistAddViewModel, Artist>();
                cfg.CreateMap<AlbumAddViewModel, Album>();
                cfg.CreateMap<TrackAddViewModel, Track>();
                cfg.CreateMap<Artist, ArtistWithDetailViewModel>();
                cfg.CreateMap<Album, AlbumWithDetailViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // ############################################################
        // RoleClaim

        public List<string> RoleClaimGetAllStrings()
        {
            return ds.RoleClaims.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()

        public IEnumerable<ArtistBaseViewModel> ArtistGetAll()
        {
            var artists = from a in ds.Artists
                          orderby a.Name
                          select a;

            return mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBaseViewModel>>(artists);
        }

        public ArtistWithDetailViewModel ArtistGetById(int id)
        {
            var artist = ds.Artists.Include("Album").SingleOrDefault(a => a.ArtistId == id);
            return artist == null ? null : mapper.Map<Artist, ArtistWithDetailViewModel>(artist);
        }

       public ArtistWithDetailViewModel ArtistAdd(ArtistAddViewModel artist)
        {
            var newArtist = ds.Artists.Add(mapper.Map<ArtistAddViewModel, Artist>(artist));
            if(newArtist != null)
            {
                newArtist.Executive = User.Name;
                newArtist.Genre = artist.Genre;
                ds.SaveChanges();
                return mapper.Map<Artist, ArtistWithDetailViewModel>(newArtist);
            }

            return null;
        }

        public IEnumerable<AlbumBaseViewModel> AlbumGetAll()
        {
            var albums = ds.Albums.OrderBy(a => a.Name);

            return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBaseViewModel>>(albums);
        }

        public AlbumWithDetailViewModel AlbumGetById(int id)
        {
            var album = ds.Albums.Include("Artist").Include("Track").SingleOrDefault(a => a.AlbumId == id);
            return album == null ? null : mapper.Map<Album, AlbumWithDetailViewModel>(album);
        }

        public AlbumWithDetailViewModel AlbumAdd(AlbumAddViewModel album)
        {
            var artists = new List<Artist>();
            var tracks = new List<Track>();
            var artistToFind = ds.Albums.Find(album.ArtistId);

            if(artistToFind == null)
            {
                return null;
            }
            else
            {
                foreach (int id in album.ArtistsIds)
                {
                    var artist = ds.Artists.SingleOrDefault(a => a.ArtistId == id);
                    if (artist != null)
                    {
                        artists.Add(artist);
                    }
                }

                foreach (int id in album.TrackIds)
                {
                    var track = ds.Tracks.SingleOrDefault(t => t.TrackId == id);
                    if (track != null)
                    {
                        tracks.Add(track);
                    }
                }

                var newAlbum = ds.Albums.Add(mapper.Map<AlbumAddViewModel, Album>(album));
                if (artists.Count() > 0)
                {
                    foreach (Artist a in artists)
                    {
                        newAlbum.Artist.Add(a);
                    }
                }

                if (tracks.Count() > 0)
                {

                    foreach (Track t in tracks)
                    {
                        newAlbum.Track.Add(t);
                    }
                }

                newAlbum.Coordinator = User.Name;
                ds.SaveChanges();
                return mapper.Map<Album, AlbumWithDetailViewModel>(newAlbum);
            }
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAll()
        {
            var tracks = from t in ds.Tracks
                         orderby t.Name
                         select t;
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(tracks);
        } 

        public TrackWithDetailViewModel TrackGetById(int id)
        {
            var track = ds.Tracks.Include("Albums.Artist").SingleOrDefault(t => t.TrackId == id);
            if (track == null)
            {
                return null;
            }
            else
            {
                var result = mapper.Map<Track, TrackWithDetailViewModel>(track);
                result.AlbumNames = track.Albums.Select(a => a.Name);
                return result;
            }
          
        }

        public TrackWithDetailViewModel TrackAdd(TrackAddViewModel track)
        {
            var albumToFind = ds.Albums.Find(track.AlbumId);
            if(albumToFind == null)
            {
                return null;
            }

            var newTrack = ds.Tracks.Add(mapper.Map<TrackAddViewModel, Track>(track));
            newTrack.Clerk = User.Name;
            newTrack.Albums.Add(albumToFind);
            ds.SaveChanges();

            return mapper.Map<Track, TrackWithDetailViewModel>(newTrack);

        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllByArtistId(int id)
        {
            var artists = ds.Artists.Include("Album.Track").SingleOrDefault(a => a.ArtistId == id);
            if(artists == null)
            {
                return null;
            }
            var tracks = new List<Track>();
            foreach(var album in artists.Album)
            {
                tracks.AddRange(album.Track);
            }
            tracks = tracks.Distinct().ToList();

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(tracks.OrderBy(t => t.Name));

        }

        public IEnumerable<GenreBaseViewModel> GenreGetAll()
        {
            var genres = from g in ds.Genres
                        orderby g.Name
                        select g;

            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreBaseViewModel>>(genres);

        }

        // Add some programmatically-generated objects to the data store
        // Can write one method, or many methods - your decision
        // The important idea is that you check for existing data first
        // Call this method from a controller action/method

        public bool LoadData()
        {
            // User name
            var user = HttpContext.Current.User.Identity.Name;

            // Monitor the progress
            bool done = false;

            // ############################################################
            // Role claims

            if (ds.RoleClaims.Count() == 0)
            {
                ds.RoleClaims.Add(new EntityModels.RoleClaim { Name = "Executive" });
                ds.RoleClaims.Add(new EntityModels.RoleClaim { Name = "Coordinator" });
                ds.RoleClaims.Add(new EntityModels.RoleClaim { Name = "Clerk" });
                ds.RoleClaims.Add(new EntityModels.RoleClaim { Name = "Staff" });
                ds.SaveChanges();
            }

            if (ds.Genres.Count() == 0)
            {
                string[] genres = { "Pop", "Rock", "Rap", "K-Pop", "Trance", "Techno", "Afropop", "House", "Reggaeton", "Chillhop" };
                foreach (string g in genres)
                {
                    ds.Genres.Add(new Genre { Name = g });
                }

                ds.SaveChanges();
            }

            if (ds.Artists.Count() == 0)
            {
                DateTime diploBirthDate = new DateTime(1978, 10, 28);
                DateTime drakeBirthDate = new DateTime(1986, 01, 24);
                DateTime swiftBirthDate = new DateTime(1989, 12, 13);
                ds.Artists.Add(new Artist { BirthName = "Thomas Wesley Pentz", Name = "Diplo", BirthOrStartDate = diploBirthDate, Executive = "admin@example.com", Genre = "Pop", UrlArtist = "https://pbs.twimg.com/profile_images/1314610204378574849/w_j0BRGk_400x400.jpg" });
                ds.Artists.Add(new Artist { BirthName = "Aubrey Drake Graham", Name = "Drake", BirthOrStartDate = drakeBirthDate, Executive = "admin@example.com", Genre = "Rap", UrlArtist = "https://images.complex.com/complex/images/c_fill,dpr_auto,f_auto,q_auto,w_1400/fl_lossy,pg_1/grh4tlkw49cijgqtgnms/toronto-police-arrest-woman-after-reports-of-disturbance-outside-drakes-mansion?fimg-ssr-default" });
                ds.Artists.Add(new Artist { BirthName = "Taylor Alison Swift", Name = "Taylor Swift", BirthOrStartDate = swiftBirthDate, Executive = "admin@example.com", Genre = "Pop", UrlArtist = "https://cms.qz.com/wp-content/uploads/2019/07/taylorswift.jpg?quality=75&strip=all&w=900&h=900&crop=1" });

                ds.SaveChanges();
            }

            if (ds.Albums.Count() == 0)
            {
                //get artist first
                var diplo = ds.Artists.SingleOrDefault(a => a.Name == "Diplo");
                //var drake = ds.Artist.SingleOrDefault(a => a.Name == "Drake");
                //var swift = ds.Artist.SingleOrDefault(a => a.Name == "Taylor Swift");

                ds.Albums.Add(new Album
                {
                    Artist = new List<Artist> { diplo },
                    Name = "Snake Oil",
                    Coordinator = "coord@example.com",
                    Genre = "Pop",
                    ReleaseDate = new DateTime(2020, 5, 29),
                    UrlAlbum = "https://media.pitchfork.com/photos/5ed0323091e9d15571ac9304/1:1/w_600/Diplo%20Presents%20Thomas%20Wesley%20Chapter%201-%20Snake%20Oil_Diplo.jpg"
                });

                ds.Albums.Add(new Album
                {
                    Artist = new List<Artist> { diplo },
                    Name = "MMXX",
                    Coordinator = "coord@example.com",
                    Genre = "Chillhop",
                    ReleaseDate = new DateTime(2020, 9, 4),
                    UrlAlbum = "https://www.edmtunes.com/wp-content/uploads/2020/09/MMXX.jpg"
                });

                ds.SaveChanges();
            }
            if (ds.Tracks.Count() == 0)
            {
                var snakeOil = ds.Albums.SingleOrDefault(a => a.Name == "Snake Oil");
                var mmxx = ds.Albums.SingleOrDefault(a => a.Name == "MMXX");

                string[] snakeOilTracks = { "So Long", "Heartless", "Lonely", "Dance with Me", "Do Si Do" };
                string[] mmxxTracks = { "I", "II", "III", "IV", "V" };

                foreach (string t in snakeOilTracks)
                {
                    ds.Tracks.Add(new Track
                    {
                        Albums = new List<Album> { snakeOil },
                        Name = t,
                        Clerk = "clerk@example.com",
                        Composers = "Diplo",
                        Genre = "Chillhop"
                    });

                }

                foreach (string t in mmxxTracks)
                {
                    ds.Tracks.Add(new Track
                    {
                        Albums = new List<Album> { mmxx },
                        Name = t,
                        Clerk = "clerk@example.com",
                        Composers = "Diplo",
                        Genre = "Chillhop"
                    });

                }
                ds.SaveChanges();
                done = true;
            }

            return done;
        }

        public bool RemoveData()
        {
            try
            {
                foreach (var e in ds.RoleClaims)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveDatabase()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

    }

    // New "RequestUser" class for the authenticated user
    // Includes many convenient members to make it easier to render user account info
    // Study the properties and methods, and think about how you could use it

    // How to use...

    // In the Manager class, declare a new property named User
    //public RequestUser User { get; private set; }

    // Then in the constructor of the Manager class, initialize its value
    //User = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);

    public class RequestUser
    {
        // Constructor, pass in the security principal
        public RequestUser(ClaimsPrincipal user)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                Principal = user;

                // Extract the role claims
                RoleClaims = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

                // User name
                Name = user.Identity.Name;

                // Extract the given name(s); if null or empty, then set an initial value
                string gn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
                if (string.IsNullOrEmpty(gn)) { gn = "(empty given name)"; }
                GivenName = gn;

                // Extract the surname; if null or empty, then set an initial value
                string sn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname).Value;
                if (string.IsNullOrEmpty(sn)) { sn = "(empty surname)"; }
                Surname = sn;

                IsAuthenticated = true;
                // You can change the string value in your app to match your app domain logic
                IsAdmin = user.HasClaim(ClaimTypes.Role, "Admin") ? true : false;
            }
            else
            {
                RoleClaims = new List<string>();
                Name = "anonymous";
                GivenName = "Unauthenticated";
                Surname = "Anonymous";
                IsAuthenticated = false;
                IsAdmin = false;
            }

            // Compose the nicely-formatted full names
            NamesFirstLast = $"{GivenName} {Surname}";
            NamesLastFirst = $"{Surname}, {GivenName}";
        }

        // Public properties
        public ClaimsPrincipal Principal { get; private set; }
        public IEnumerable<string> RoleClaims { get; private set; }

        public string Name { get; set; }

        public string GivenName { get; private set; }
        public string Surname { get; private set; }

        public string NamesFirstLast { get; private set; }
        public string NamesLastFirst { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public bool IsAdmin { get; private set; }

        public bool HasRoleClaim(string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(ClaimTypes.Role, value) ? true : false;
        }

        public bool HasClaim(string type, string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(type, value) ? true : false;
        }
    }

}