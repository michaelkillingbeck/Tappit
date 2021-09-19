import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { IPerson } from "./person";
import { IPersonDetail } from './persondetail';

@Injectable({
    providedIn: 'root'
})

export class PeopleService {
    private personUrl = 'http://localhost:5000/person';

    constructor(private httpClient: HttpClient) {}

    getAllPeople(): Observable<IPerson[]> {
        return this.httpClient.get<IPerson[]>(this.personUrl + '/getall');
    }

    getPersonById(id: number): Observable<IPersonDetail> {
        return this.httpClient.get<IPersonDetail>(`${this.personUrl}/get?id=${id}`);
    }
}