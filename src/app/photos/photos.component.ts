import {Component, Input, OnInit} from '@angular/core';
import {Photo} from "../models/Photo";
import { PhotoService} from "../services/photo.service";
import {Album} from "../models/Album";

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  @Input() album?: Album; // selected album
  photos: Photo[] = []; // array of all photos

  constructor(private photoService:PhotoService) { }

  ngOnInit() {
    this.photoService.getPhotos().subscribe(photos => {
      this.photos = photos;
    })
  }
}
