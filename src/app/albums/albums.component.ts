import { Component, OnInit, Input } from '@angular/core';
import { Album} from "../models/Album";
import { AlbumService} from "../services/album.service";
import {User} from "../models/User";
import { PhotoService} from "../services/photo.service";

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css'],
})
export class AlbumsComponent implements OnInit {
  @Input() user?: User;
  selectedAlbum? : Album;
  albums:Album[] = [];

  constructor(private albumService:AlbumService, private photoService:PhotoService) { }

  ngOnInit(): void {
    this.albumService.getAlbums().subscribe(albums => {
      this.albums = albums;
    })
  }

  // when album is clicked -----------------------------------------
  onSelect(album: Album): void {
    this.selectedAlbum = album;
  }


}
