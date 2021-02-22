import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import MGAsData from './components/MGAsData';
import CarriersData from './components/CarriersData';
import AdvisorsData from './components/AdvisorsData';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/fetch-mgas/:startDateIndex?' component={MGAsData} />
        <Route path='/fetch-carriers/:startDateIndex?' component={CarriersData} />
        <Route path='/fetch-advisors/:startDateIndex?' component={AdvisorsData} />
    </Layout>
);
