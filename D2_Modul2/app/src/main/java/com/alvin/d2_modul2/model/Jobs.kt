package com.alvin.d2_modul2.model

import android.os.Parcel
import android.os.Parcelable

data class Jobs(
    val id: Int,
    val name: String,
    val companyName: String,
    val locationRegion: String,
    val locationType: String,
    val yearOfExperience: String,
    val quota: Int,
): Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readInt()
    ) {
    }

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(id)
        parcel.writeString(name)
        parcel.writeString(companyName)
        parcel.writeString(locationType)
        parcel.writeString(locationRegion)
        parcel.writeString(yearOfExperience)
        parcel.writeInt(quota)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Jobs> {
        override fun createFromParcel(parcel: Parcel): Jobs {
            return Jobs(parcel)
        }

        override fun newArray(size: Int): Array<Jobs?> {
            return arrayOfNulls(size)
        }
    }
}
