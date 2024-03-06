import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';

import { Auth0Provider } from '@auth0/auth0-react';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

const onRedirectCallback = (appState) => {
    window.history.replaceState(
        {},
        document.title,
        appState && appState.targetUrl ? appState.targetUrl
            : window.location.pathname
    );
};

root.render(
    <Auth0Provider
        domain="dev-dj6ish0w23qeox8s.us.auth0.com"
        clientId="wotjiXld8n0lFdBbvW78SEyfKR3J1jAw"
        authorizationParams={
            {
                redirect_uri: window.location.origin,
                onRedirectCallback: onRedirectCallback
            }
        }
    >
        <BrowserRouter basename={baseUrl}>
            <App />
        </BrowserRouter>
    </Auth0Provider>);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
serviceWorkerRegistration.unregister();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
