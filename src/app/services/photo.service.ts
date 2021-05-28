import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import { Photo} from "../models/Photo";
// comments: add routing so loads on separate pages
// comments: have backend so it calls corresponding albums and photos instead of
// hiding it on the front end
@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  private photosUrl = 'https://localhost:5001/photos/getPhotos'


  constructor(private http:HttpClient) {}

  // gets all photos -------------------------------------------
  getPhotos(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.photosUrl)
  }

  // gets one photo -------------------------------------------
  // getPhoto(id: number): Observable<Photo> {
  //   const url = `${this.photosUrl}/${id}`;
  //   return this.http.get<Photo>(url);
  // }

}
