import React from 'react';
import Navbar from '../../Components/Navbar/Navbar';
import SongCard from '../../Components/SongCard/SongCard';
import LightDarkModeButton from '../../Components/LightDarkModeButton/LightDarkModeButton';

function Home() {
  return (
      <>
          <Navbar />
          <SongCard />
          <LightDarkModeButton />
      </>
  );
}

export default Home;