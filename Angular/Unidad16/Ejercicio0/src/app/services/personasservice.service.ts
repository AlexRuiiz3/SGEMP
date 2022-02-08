import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Persona } from '../interfaces/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonasserviceService {

  urlApi = "https://crudpersonasasp-alexruiz.azurewebsites.net/api/personas";

  constructor(private httpClient:HttpClient) { }

  getPersonas(): Observable<Persona[]>{
    return this.httpClient.get<Persona[]>(this.urlApi);
  }
}
