import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import MGAsData from './components/MGAsData';
import CarriersData from './components/CarriersData';
import AdvisorsData from './components/AdvisorsData';
import './custom.css'
import CarrierDetails from './components/CarrierDetails';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/fetch-mgas' component={MGAsData} />
        <Route path='/fetch-carriers' component={CarriersData} />
        <Route path='/fetch-carriers/:id' component={CarrierDetails} />
        <Route path='/fetch-advisors' component={AdvisorsData} />
    </Layout>
);
