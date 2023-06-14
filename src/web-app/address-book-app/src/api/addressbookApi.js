import { API_URL } from '../constants';
import axios from 'axios';

export const addressbookApi = axios.create({
    baseURL: API_URL
});