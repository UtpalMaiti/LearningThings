import { Injectable } from '@angular/core';
import { PlaceLocation } from './logic/PlaceLocation';

@Injectable({
  providedIn: 'root'
})
export class GeolocationService {

  constructor() { }
  requestLocation(callback) {
    //W3c Geolocation API
    navigator.geolocation.getCurrentPosition(
      position => {
        callback(position.coords)
      },
      error => {
        callback(null);
      }
    )

  }
  getMapLocation(location: PlaceLocation) {
    //Universal Link
    //<a href="https://maps.google.com/?q=Eiffel+Tower"
    //<a href="https://maps.google.com/?q=34.44,56.44"
    let query = "";
    if (location.latitude) {
      query = location.latitude + "," + location.longitude;
    } else {
      query = `${location.address},${location.city}`
    }

    if (/iPad|iPhone|iPod/.test(navigator.userAgent)) {
      return `https"//maps.apple.com/?q=${query}`;
    } else {
      return `https"//maps.google.com/?q=${query}`;
    }

  }
}
