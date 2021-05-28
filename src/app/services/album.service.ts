import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import { Album} from "../models/Album";

@Injectable({
  providedIn: 'root'
})
export class AlbumService {
  private albumsUrl = 'https://localhost:5001/Albums/getAlbums'


  constructor(private http:HttpClient) { }

  // get all albums --------------------------------------------
  getAlbums():Observable<Album[]> {
    return this.http.get<Album[]>(this.albumsUrl);
  }

  // get one album ---------------------------------------
  // getAlbum(id: number): Observable<Album> {
  //   const url = `${this.albumsUrl}/${id}`;
  //   return this.http.get<Album>(url);
  // }

}
