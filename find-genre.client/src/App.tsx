import { useEffect, useState } from 'react';
import './App.css';
import SongCard from './Components/SongCard/SongCard';
import Navbar from './Components/Navbar/Navbar';

function App() {


    return (
        <div>
            <Navbar />
            <SongCard />
        </div>
    );
}

export default App;