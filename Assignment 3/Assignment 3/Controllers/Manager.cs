// **************************************************
// WEB524 Project Template V1 == d3e97a72-7b14-40da-b98c-b2da32973591
// Do not change this header.
// **************************************************

using Assignment_3.EntityModels;
using Assignment_3.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();
                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>();
                cfg.CreateMap<TrackAddViewModel, Track>();
                cfg.CreateMap<Album, AlbumBaseViewModel>();
                cfg.CreateMap<Artist, ArtistBaseViewModel>();
                cfg.CreateMap<Playlist, PlaylistBaseViewModel>();
                cfg.CreateMap<PlaylistBaseViewModel, PlaylistEditTracksFormViewModel>();
                cfg.CreateMap<PlaylistEditTracksViewModel, Playlist>();
                cfg.CreateMap<MediaType, MediaTypeBaseViewModel>();

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // Add your methods and call them from controllers.  Use the suggested naming convention.
        // Ensure that your methods accept and deliver ONLY view model objects and collections.
        // When working with collections, the return type is almost always IEnumerable<T>.
        public IEnumerable<AlbumBaseViewModel> AlbumGetAll()
        {
            var allAlbums = from a in ds.Albums
                            orderby a.Title
                            select a;
            return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBaseViewModel>>(allAlbums);
        }

        public AlbumBaseViewModel AlbumGetById(int id)
        {
            var album = ds.Albums.Find(id);
            return album == null ? null : mapper.Map<Album, AlbumBaseViewModel>(album);
        }

        public IEnumerable<ArtistBaseViewModel> ArtistGetAll()
        {
            var allArtists = from a in ds.Artists
                             orderby a.Name
                             select a;

            return mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBaseViewModel>>(allArtists);

        }

        public IEnumerable<MediaTypeBaseViewModel> MediaTypeGetAll()
        {
            var allMediaTypes = from m in ds.MediaTypes
                                orderby m.Name
                                select m;

            return mapper.Map<IEnumerable<MediaType>, IEnumerable<MediaTypeBaseViewModel>>(allMediaTypes);
        }

        public MediaTypeBaseViewModel MediaTypeGetById(int id)
        {
            var mediaType = ds.MediaTypes.Include("Tracks").SingleOrDefault(t => t.MediaTypeId == id);

            return mediaType == null ? null : mapper.Map<MediaType, MediaTypeBaseViewModel>(mediaType);
        }
        public IEnumerable<TrackWithDetailViewModel> TrackGetAllWithDetail()
        {
            var allTracks = ds.Tracks.Include("MediaType").Include("Album").Include("Album.Artist").OrderBy(t => t.Name);
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(allTracks);
        }

        public TrackWithDetailViewModel TrackGetOneWithDetail(int id)
        {
            var track = ds.Tracks.Include("MediaType").Include("Album").Include("Album.Artist").SingleOrDefault(t => t.TrackId == id);
            if(track == null)
            {
                return null;
            }
            return mapper.Map<Track, TrackWithDetailViewModel>(track);
        }

        public TrackWithDetailViewModel TrackAdd(TrackAddViewModel newTrack)
        {
            var newTrackAlbum = ds.Albums.Find(newTrack.AlbumId);
            
            if(newTrackAlbum == null)
            {
                return null;
            }

            var newTrackMediaType = ds.MediaTypes.Find(newTrack.MediaTypeId);

            if (newTrackMediaType == null)
            {
                return null;
            }

            //always attempt to find first
            var newAddedTrack = ds.Tracks.Add(mapper.Map<TrackAddViewModel, Track>(newTrack));
            newAddedTrack.Album = newTrackAlbum;
            newAddedTrack.MediaType = newTrackMediaType;

            ds.SaveChanges();

            return newAddedTrack == null ? null : mapper.Map<Track, TrackWithDetailViewModel>(newAddedTrack);
        }

        public IEnumerable<PlaylistBaseViewModel> PlaylistGetAll()
        {
            return mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistBaseViewModel>>(ds.Playlists.Include("Tracks").OrderBy(p => p.Name));
        }

        public PlaylistBaseViewModel PlaylistGetById(int id)
        {
  
            var playlist = ds.Playlists.Include("Tracks").SingleOrDefault(p => p.PlaylistId == id);
            if(playlist == null)
            {
                return null;
            }
            playlist.Tracks.OrderBy(t => t.TrackId);
            return mapper.Map<Playlist, PlaylistBaseViewModel>(playlist);
        }

        public PlaylistBaseViewModel PlaylistEditTracks(PlaylistEditTracksViewModel p)
        {
            var obj = ds.Playlists.Include("Tracks").SingleOrDefault(playlist => playlist.PlaylistId == p.PlaylistId);
            if(obj == null)
            {
                return null;
            }
            else
            {
                obj.Tracks.Clear();
                foreach(var trackId in p.TrackIds)
                {
                    var track = ds.Tracks.Find(trackId);
                    obj.Tracks.Add(track);
                }
            }
            ds.SaveChanges();
            return mapper.Map<Playlist, PlaylistBaseViewModel>(obj);
        }
    }
}