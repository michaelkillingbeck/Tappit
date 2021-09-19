import { Component, OnInit } from "@angular/core";
import { SportsService } from "./sports.service";
import { ISportsSummary } from "./sportsSummaries";

@Component({
    templateUrl: "./sports-list.component.html"
})

export class FavouriteSportsList implements OnInit {
    pageTitle: string = "Sports";
    sportsSummaries: ISportsSummary[] = [];

    constructor(private sportsService: SportsService) {}

    ngOnInit(): void {
        this.sportsService.getAllFavouritesSummaries().subscribe({
            next: sports => this.sportsSummaries = sports
        });
    }
}