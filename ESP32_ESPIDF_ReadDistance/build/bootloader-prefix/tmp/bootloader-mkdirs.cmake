# Distributed under the OSI-approved BSD 3-Clause License.  See accompanying
# file Copyright.txt or https://cmake.org/licensing for details.

cmake_minimum_required(VERSION 3.5)

file(MAKE_DIRECTORY
  "C:/Espressif/frameworks/esp-idf-v5.2.1/components/bootloader/subproject"
  "D:/HK/HK232/DLCN/BTL/BTL 2/ESP32_ESPIDF_ReadDistance/build/bootloader"
  "D:/HK/HK232/DLCN/BTL/BTL 2/ESP32_ESPIDF_ReadDistance/build/bootloader-prefix"
  "D:/HK/HK232/DLCN/BTL/BTL 2/ESP32_ESPIDF_ReadDistance/build/bootloader-prefix/tmp"
  "D:/HK/HK232/DLCN/BTL/BTL 2/ESP32_ESPIDF_ReadDistance/build/bootloader-prefix/src/bootloader-stamp"
  "D:/HK/HK232/DLCN/BTL/BTL 2/ESP32_ESPIDF_ReadDistance/build/bootloader-prefix/src"
  "D:/HK/HK232/DLCN/BTL/BTL 2/ESP32_ESPIDF_ReadDistance/build/bootloader-prefix/src/bootloader-stamp"
)

set(configSubDirs )
foreach(subDir IN LISTS configSubDirs)
    file(MAKE_DIRECTORY "D:/HK/HK232/DLCN/BTL/BTL 2/ESP32_ESPIDF_ReadDistance/build/bootloader-prefix/src/bootloader-stamp/${subDir}")
endforeach()
if(cfgdir)
  file(MAKE_DIRECTORY "D:/HK/HK232/DLCN/BTL/BTL 2/ESP32_ESPIDF_ReadDistance/build/bootloader-prefix/src/bootloader-stamp${cfgdir}") # cfgdir has leading slash
endif()
