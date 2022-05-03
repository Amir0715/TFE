import React from 'react'
import InputBase from '@mui/material/InputBase';
import SearchIcon from '@mui/icons-material/Search';
import InputAdornment from '@mui/material/InputAdornment';

const SearchInput = () => {
  return (
    <InputBase
    placeholder='Search'
    sx={{
      borderRadius: 100,
      backgroundColor: 'white',
      p: "12px 16px 12px 16px",
      width: "350px",
      height: "40px",
    }}
    startAdornment={
        <InputAdornment position="start">
          <SearchIcon />
        </InputAdornment>
      }
    />
  )
}

export default SearchInput
