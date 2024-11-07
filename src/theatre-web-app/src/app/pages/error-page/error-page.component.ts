import { Component, Query } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { QueryErrorParams } from '@data/services/error-handle.service';

@Component({
    selector: 'app-error-page',
    standalone: true,
    imports: [RouterLink],
    templateUrl: './error-page.component.html',
    styleUrl: './error-page.component.less',
})
export class ErrorPageComponent {
    errorStatus?: number;
    errorMessage?: string;

    constructor(private route: ActivatedRoute) {
        this.route.queryParams.subscribe((params) => {
            const { status, message } = params as QueryErrorParams;

            this.errorStatus = status;
            this.errorMessage = message;
        });
    }
}
