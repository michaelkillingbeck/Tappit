import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ISportsSummary } from "./sportsSummaries";

@Injectable({
    providedIn: 'root'
})

export class SportsService {
    private sportsUrl = 'http://localhost:5000/sport';

    constructor(private httpClient: HttpClient) {}

    getAllFavouritesSummaries(): Observable<ISportsSummary[]> {
        return this.httpClient.get<ISportsSummary[]>(this.sportsUrl + '/getallfavouritesummaries');
    }
}