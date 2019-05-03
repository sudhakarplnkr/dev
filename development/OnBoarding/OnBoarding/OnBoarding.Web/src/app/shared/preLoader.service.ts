import { Injectable } from '@angular/core';

@Injectable()
export class PreLoaderService {
    public static fullLoadingCount: number = 0;

    getPreloaderCount(): number {
        return PreLoaderService.fullLoadingCount;
    }
    showPreloader(): any {
        PreLoaderService.fullLoadingCount++;
    }
    hidePreloader(): any {
        PreLoaderService.fullLoadingCount--;
    }
}
