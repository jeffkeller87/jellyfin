﻿using MediaBrowser.Controller.Entities;
using MediaBrowser.Model.Providers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Model.Configuration;

namespace MediaBrowser.Controller.Subtitles
{
    public interface ISubtitleManager
    {
        /// <summary>
        /// Occurs when [subtitle download failure].
        /// </summary>
        event EventHandler<SubtitleDownloadFailureEventArgs> SubtitleDownloadFailure;

        /// <summary>
        /// Occurs when [subtitles downloaded].
        /// </summary>
        event EventHandler<SubtitleDownloadEventArgs> SubtitlesDownloaded;

        /// <summary>
        /// Adds the parts.
        /// </summary>
        /// <param name="subtitleProviders">The subtitle providers.</param>
        void AddParts(IEnumerable<ISubtitleProvider> subtitleProviders);

        /// <summary>
        /// Searches the subtitles.
        /// </summary>
        Task<RemoteSubtitleInfo[]> SearchSubtitles(Video video,
            string language,
            bool? isPerfectMatch,
            CancellationToken cancellationToken);

        /// <summary>
        /// Searches the subtitles.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task{IEnumerable{RemoteSubtitleInfo}}.</returns>
        Task<RemoteSubtitleInfo[]> SearchSubtitles(SubtitleSearchRequest request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Downloads the subtitles.
        /// </summary>
        Task DownloadSubtitles(Video video, string subtitleId, CancellationToken cancellationToken);

        /// <summary>
        /// Downloads the subtitles.
        /// </summary>
        Task DownloadSubtitles(Video video, LibraryOptions libraryOptions, string subtitleId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the remote subtitles.
        /// </summary>
        Task<SubtitleResponse> GetRemoteSubtitles(string id, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the subtitles.
        /// </summary>
        Task DeleteSubtitles(BaseItem item, int index);

        /// <summary>
        /// Gets the providers.
        /// </summary>
        SubtitleProviderInfo[] GetSupportedProviders(BaseItem item);
    }
}
