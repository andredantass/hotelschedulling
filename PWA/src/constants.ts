import { environment } from './environments/environment.prod';

export class Constants {
    static readonly DOMAIN = environment.domain;
    static readonly API_BASE_URL = environment.apiUrl;
    static readonly API_KEY = environment.apiKey;
    static readonly PARENT_DOMAIN = environment.parentDomain;
    static readonly IS_CANVAS_PROJECT = true;
    static readonly GA_KEY = environment.gaKey;
}
